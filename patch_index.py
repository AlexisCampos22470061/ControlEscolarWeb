import re

with open('Views/Home/Index.cshtml', 'r', encoding='utf-8') as f:
    content = f.read()

# We want to redesign the #panelResultado section.
# We will extract the current sections and reconstruct them with tabs.

# Cabecera needs Name, Matricula, Promedio, and Estatus.
# The current HTML has these pieces scattered. Let's just create a new HTML for panelResultado.

new_panel_resultado = """
    <!-- Contenedor de Resultado -->
    <div id="panelResultado" class="hidden space-y-6">

        <!-- Cabecera del Expediente -->
        <div class="bg-white rounded-2xl p-6 shadow-sm border border-slate-200 flex flex-col md:flex-row justify-between items-start md:items-center gap-4">
            <div>
                <h3 class="text-2xl font-black text-slate-900 tracking-tight" id="txtNombreCompleto">-</h3>
                <p class="text-sm text-slate-500 font-mono mt-0.5" id="txtMatricula">-</p>
            </div>
            <div class="flex items-center gap-6">
                <div class="text-center">
                    <p class="text-xs text-slate-400 uppercase tracking-wider font-bold">Promedio</p>
                    <span class="text-3xl font-black text-indigo-900" id="txtPromedio">-</span>
                </div>
                <div class="text-center">
                    <p class="text-xs text-slate-400 uppercase tracking-wider font-bold mb-1">Estatus</p>
                    <span id="badgeEstatus" class="inline-block px-4 py-1 rounded-full text-sm font-black border">
                        -
                    </span>
                </div>
            </div>
        </div>

        <!-- Navegación por Pestañas -->
        <div class="bg-white rounded-2xl shadow-sm border border-slate-200 overflow-hidden">
            <div class="flex border-b border-slate-200 bg-slate-50">
                <button onclick="mostrarPestana('generales')" id="btnTabGenerales" class="tab-btn flex-1 py-4 text-sm font-bold text-indigo-700 border-b-2 border-indigo-700 bg-white transition">Generales</button>
                <button onclick="mostrarPestana('materias')" id="btnTabMaterias" class="tab-btn flex-1 py-4 text-sm font-bold text-slate-500 border-b-2 border-transparent hover:text-slate-700 hover:bg-slate-100 transition">Materias</button>
                <button onclick="mostrarPestana('situacion')" id="btnTabSituacion" class="tab-btn flex-1 py-4 text-sm font-bold text-slate-500 border-b-2 border-transparent hover:text-slate-700 hover:bg-slate-100 transition">Situación</button>
            </div>

            <div class="p-6">
                <!-- Pestaña 1: Generales -->
                <div id="tabGenerales" class="tab-content block">
                    <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
                        <!-- Identificación -->
                        <div>
                            <h4 class="text-sm font-bold text-slate-800 border-b pb-2 mb-3">Identificación (INE)</h4>
                            <p class="text-sm"><span class="text-slate-500">CURP:</span> <span class="font-semibold" id="txtCurp">-</span></p>
                            <p class="text-sm"><span class="text-slate-500">Fecha Nac:</span> <span class="font-semibold" id="txtFechaNac">-</span></p>
                            <p class="text-sm"><span class="text-slate-500">Género:</span> <span class="font-semibold" id="txtGenero">-</span></p>
                        </div>
                        
                        <!-- Domicilio -->
                        <div>
                            <h4 class="text-sm font-bold text-slate-800 border-b pb-2 mb-3">Domicilio</h4>
                            <p class="text-sm"><span class="text-slate-500">Calle y Núm:</span> <span class="font-semibold" id="txtCalle">-</span></p>
                            <p class="text-sm"><span class="text-slate-500">Colonia:</span> <span class="font-semibold" id="txtColonia">-</span></p>
                            <p class="text-sm"><span class="text-slate-500">C.P.:</span> <span class="font-semibold" id="txtCp">-</span></p>
                            <p class="text-sm"><span class="text-slate-500">Municipio/Entidad:</span> <span class="font-semibold" id="txtMunicipio">-</span></p>
                        </div>

                        <!-- Contacto -->
                        <div>
                            <h4 class="text-sm font-bold text-slate-800 border-b pb-2 mb-3">Contacto</h4>
                            <p class="text-sm"><span class="text-slate-500">Teléfono:</span> <span class="font-semibold" id="txtTelefono">-</span></p>
                            <p class="text-sm"><span class="text-slate-500">Correo:</span> <span class="font-semibold" id="txtCorreo">-</span></p>
                        </div>

                        <!-- Datos Escolares -->
                        <div>
                            <h4 class="text-sm font-bold text-slate-800 border-b pb-2 mb-3">Datos Escolares</h4>
                            <p class="text-sm"><span class="text-slate-500">Horario/Grupo:</span> <span class="font-semibold" id="txtHorario">-</span></p>
                            <p class="text-sm"><span class="text-slate-500">Campus/Sede:</span> <span class="font-semibold" id="txtCampus">-</span></p>
                            <p class="text-sm"><span class="text-slate-500">Fecha Registro:</span> <span class="font-semibold" id="txtFechaReg">-</span></p>
                        </div>
                    </div>
                </div>

                <!-- Pestaña 2: Materias -->
                <div id="tabMaterias" class="tab-content hidden">
                    <div class="flex flex-col sm:flex-row sm:items-center justify-between gap-2 mb-4">
                        <div>
                            <h4 class="font-bold text-slate-900 text-lg">Historial de Módulos (8 Materias)</h4>
                            <p class="text-xs text-slate-500">Captura directa de calificación</p>
                        </div>
                    </div>
                    <div class="overflow-x-auto border rounded-xl">
                        <table class="w-full text-left text-sm">
                            <thead class="bg-slate-50 text-slate-600 text-xs uppercase tracking-wider border-b border-slate-200">
                                <tr>
                                    <th class="py-3.5 px-4 w-14 text-center">#</th>
                                    <th class="py-3.5 px-6">Módulo / Materia</th>
                                    <th class="py-3.5 px-4 w-36 text-center">Calificación</th>
                                    <th class="py-3.5 px-4 w-36 text-center">Acreditado</th>
                                    <th class="py-3.5 px-4 w-32 text-center">Acción</th>
                                </tr>
                            </thead>
                            <tbody id="tbodyModulos" class="divide-y divide-slate-100 text-slate-700"></tbody>
                        </table>
                    </div>
                </div>

                <!-- Pestaña 3: Situación -->
                <div id="tabSituacion" class="tab-content hidden">
                    <h4 class="font-bold text-slate-900 text-lg mb-2">Control Escolar</h4>
                    <p class="text-sm text-slate-500 mb-6">Modifica el estado actual del alumno.</p>
                    
                    <div class="grid grid-cols-1 sm:grid-cols-3 gap-4">
                        <button onclick="cambiarEstatus('Activo')" class="flex flex-col items-center justify-center p-6 rounded-xl border-2 border-emerald-200 bg-emerald-50 hover:bg-emerald-100 transition gap-2">
                            <i class="fa-solid fa-user-check text-3xl text-emerald-600"></i>
                            <span class="font-bold text-emerald-800">Activo</span>
                            <span class="text-xs text-emerald-600 text-center">Estudiante asiste y cursa materias normalmente.</span>
                        </button>
                        <button onclick="cambiarEstatus('Inactivo')" class="flex flex-col items-center justify-center p-6 rounded-xl border-2 border-rose-200 bg-rose-50 hover:bg-rose-100 transition gap-2">
                            <i class="fa-solid fa-user-xmark text-3xl text-rose-600"></i>
                            <span class="font-bold text-rose-800">Inactivo</span>
                            <span class="text-xs text-rose-600 text-center">Baja temporal, definitiva o adeuda documentos.</span>
                        </button>
                        <button onclick="cambiarEstatus('Finalizado')" class="flex flex-col items-center justify-center p-6 rounded-xl border-2 border-indigo-200 bg-indigo-50 hover:bg-indigo-100 transition gap-2">
                            <i class="fa-solid fa-user-graduate text-3xl text-indigo-600"></i>
                            <span class="font-bold text-indigo-800">Finalizado</span>
                            <span class="text-xs text-indigo-600 text-center">Alumno egresado, concluyó con éxito.</span>
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
"""

start_idx = content.find('    <!-- Contenedor de Resultado -->')
end_idx = content.find('@section Scripts {')

new_content = content[:start_idx] + new_panel_resultado + "\n" + content[end_idx:]

# Also inject JS functions for tabs and status change.
js_functions = """
    function mostrarPestana(idTab) {
        // Ocultar todos
        document.querySelectorAll('.tab-content').forEach(el => el.classList.add('hidden'));
        document.querySelectorAll('.tab-btn').forEach(el => {
            el.classList.remove('text-indigo-700', 'border-indigo-700', 'bg-white');
            el.classList.add('text-slate-500', 'border-transparent');
        });

        // Mostrar seleccionado
        document.getElementById('tab' + idTab.charAt(0).toUpperCase() + idTab.slice(1)).classList.remove('hidden');
        
        let btn = document.getElementById('btnTab' + idTab.charAt(0).toUpperCase() + idTab.slice(1));
        btn.classList.remove('text-slate-500', 'border-transparent');
        btn.classList.add('text-indigo-700', 'border-indigo-700', 'bg-white');
    }

    async function cambiarEstatus(nuevoEstatus) {
        if (!alumnoIdActual) return;

        try {
            const resp = await fetch("/Home/CambiarEstatus", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({
                    alumnoId: alumnoIdActual,
                    estatus: nuevoEstatus
                })
            });

            if (resp.ok) {
                // Refrescar para ver el cambio
                ejecutarBusqueda();
            } else {
                const err = await resp.json();
                alert(err.error || "No se pudo actualizar el estatus.");
            }
        } catch (e) {
            alert("Error de conexión al guardar.");
        }
    }
"""

# add it before // Buscar el ejemplo de inicio automáticamente
js_insert_idx = new_content.find('// Buscar el ejemplo de inicio')
if js_insert_idx != -1:
    new_content = new_content[:js_insert_idx] + js_functions + "\n    " + new_content[js_insert_idx:]
else:
    print("Could not find the insertion point for JS functions")

with open('Views/Home/Index.cshtml', 'w', encoding='utf-8') as f:
    f.write(new_content)

print("Patch applied successfully.")


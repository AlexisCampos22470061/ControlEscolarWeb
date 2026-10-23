import re

with open('Views/Home/Index.cshtml', 'r', encoding='utf-8') as f:
    content = f.read()

# Replace the HTML structure inside panelResultado
new_html = '''        <!-- Sección 2: Generales -->
        <div class="bg-white rounded-2xl p-6 shadow-sm border border-slate-200">
            <h3 class="text-2xl font-black text-slate-900 tracking-tight" id="txtNombreCompleto">-</h3>
            <p class="text-sm text-slate-500 font-mono mt-0.5" id="txtMatricula">-</p>

            <div class="grid grid-cols-1 md:grid-cols-2 gap-6 mt-6">
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

        <div class="grid grid-cols-1 xl:grid-cols-3 gap-6">
            <!-- Sección 3: Historial de Materias -->
            <div class="xl:col-span-2 bg-white rounded-2xl shadow-sm border border-slate-200 overflow-hidden">
                <div class="px-6 py-4 border-b border-slate-100 flex flex-col sm:flex-row sm:items-center justify-between gap-2">
                    <div>
                        <h4 class="font-bold text-slate-900 text-lg">Historial de Módulos (8 Módulos)</h4>
                        <p class="text-xs text-slate-500">Captura directa de calificación</p>
                    </div>
                </div>

                <div class="overflow-x-auto">
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

            <!-- Sección 4: Situación -->
            <div class="bg-white rounded-2xl shadow-sm border border-slate-200 p-6 flex flex-col items-center text-center">
                 <h4 class="font-bold text-slate-900 text-lg mb-6 w-full text-left">Situación Escolar</h4>
                 <div class="flex-1 flex flex-col justify-center items-center w-full space-y-6">
                     <div>
                         <p class="text-xs text-slate-400 uppercase tracking-wider font-bold mb-2">Estatus Actual</p>
                         <span id="badgeEstatus" class="inline-block px-6 py-2 rounded-full text-sm font-black border">
                             -
                         </span>
                     </div>
                     <div class="w-full border-t border-slate-100"></div>
                     <div>
                         <p class="text-xs text-slate-400 uppercase tracking-wider font-bold mb-2">Promedio General</p>
                         <span class="text-5xl font-black text-indigo-900" id="txtPromedio">-</span>
                     </div>
                 </div>
            </div>
        </div>'''

content = re.sub(r'<!-- Tarjeta de Datos Generales -->.*</div>\s*<!-- Tabla Historial 8 Módulos -->.*</div>\s*</div>', new_html + '\n\n    </div>', content, flags=re.DOTALL)

# Update Javascript dibujarAlumno
js_replacement = '''    function dibujarAlumno(data) {
        const al = data.alumno;
        document.getElementById("txtNombreCompleto").textContent = al.nombreCompleto;
        document.getElementById("txtMatricula").textContent = al.matricula ? Matrícula:  : "Sin Matrícula Asignada";
        
        // Identificación
        document.getElementById("txtCurp").textContent = al.curp || "No registrada";
        document.getElementById("txtFechaNac").textContent = al.fechaNacimiento ? al.fechaNacimiento.split('T')[0] : "No registrada";
        document.getElementById("txtGenero").textContent = al.genero || "No registrado";
        
        // Domicilio
        document.getElementById("txtCalle").textContent = al.calleNumero || "No registrada";
        document.getElementById("txtColonia").textContent = al.colonia || "No registrada";
        document.getElementById("txtCp").textContent = al.codigoPostal || "No registrado";
        document.getElementById("txtMunicipio").textContent = al.municipioEntidad || "No registrado";
        
        // Contacto
        document.getElementById("txtTelefono").textContent = al.telefono || "Sin teléfono";
        document.getElementById("txtCorreo").textContent = al.correo || "Sin correo";
        
        // Escolares
        document.getElementById("txtHorario").textContent = al.horario || "Sin horario";
        document.getElementById("txtCampus").textContent = al.campus || "Sin campus";
        document.getElementById("txtFechaReg").textContent = al.fechaRegistro ? al.fechaRegistro.split('T')[0] : "No registrada";

        // Situación
        document.getElementById("txtPromedio").textContent = data.promedio !== null ? data.promedio : "-";

        const badgeEstatus = document.getElementById("badgeEstatus");
        badgeEstatus.textContent = al.estatus || "ACTIVO";
        badgeEstatus.className = "inline-block px-6 py-2 rounded-full text-sm font-black border ";
        
        let estatusStr = (al.estatus || "ACTIVO").toUpperCase();
        if (estatusStr === "ACTIVO") {
            badgeEstatus.className += "bg-emerald-50 text-emerald-700 border-emerald-200";
        } else if (estatusStr === "INACTIVO") {
            badgeEstatus.className += "bg-rose-50 text-rose-700 border-rose-200";
        } else if (estatusStr === "FINALIZADO") {
            badgeEstatus.className += "bg-indigo-50 text-indigo-700 border-indigo-200";
        } else {
            badgeEstatus.className += "bg-slate-50 text-slate-700 border-slate-200";
        }

        const tbody = document.getElementById("tbodyModulos");
        tbody.innerHTML = "";

        data.modulos.forEach(m => {
            const calVal = m.calificacion !== null ? m.calificacion : "";
            let badge = '<span class="px-2.5 py-1 rounded-full text-[11px] font-bold bg-slate-100 text-slate-500">Pendiente</span>';
            if (m.calificacion !== null) {
                badge = m.acreditado 
                    ? '<span class="px-2.5 py-1 rounded-full text-[11px] font-bold bg-emerald-100 text-emerald-700">Acreditado</span>'
                    : '<span class="px-2.5 py-1 rounded-full text-[11px] font-bold bg-rose-100 text-rose-700">No Acreditado</span>';
            }

            const fila = document.createElement("tr");
            fila.className = "hover:bg-slate-50/70 transition";
            fila.innerHTML = 
                <td class="py-3 px-4 text-center font-bold text-slate-400 font-mono"></td>
                <td class="py-3 px-6 font-semibold text-slate-800"></td>
                <td class="py-3 px-4 text-center">
                    <input 
                        type="number" 
                        step="0.1" 
                        min="0" 
                        max="10" 
                        id="input-cal-"
                        value="" 
                        class="w-20 px-2 py-1.5 text-center font-bold text-slate-800 border border-slate-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-indigo-600 bg-white"
                    />
                </td>
                <td class="py-3 px-4 text-center"></td>
                <td class="py-3 px-4 text-center">
                    <button 
                        type="button" 
                        onclick="guardarNota()"
                        class="text-xs bg-indigo-50 hover:bg-indigo-600 hover:text-white text-indigo-700 font-bold px-3 py-1.5 rounded-lg transition border border-indigo-200">
                        Guardar
                    </button>
                </td>
            ;
            tbody.appendChild(fila);
        });
    }'''

content = re.sub(r'function dibujarAlumno\(data\) \{.*?(?=async function guardarNota)', js_replacement + '\n\n    ', content, flags=re.DOTALL)

with open('Views/Home/Index.cshtml', 'w', encoding='utf-8') as f:
    f.write(content)

//localStorage.removeItem("asignaturas");

// Obtener elementos del DOM
const openModalBtn = document.getElementById("openModalBtn");
const modal = document.getElementById("modal");
const closeModal = document.getElementById("closeModal");
const asignaturaForm = document.getElementById("asignaturaForm");
const asignaturaList = document.getElementById("asignaturaList");

// Abrir el modal
openModalBtn.addEventListener("click", () => {
    modal.style.display = "block";
});

// Cerrar el modal
closeModal.addEventListener("click", () => {
    modal.style.display = "none";
});

// Guardar la asignatura en el localStorage
asignaturaForm.addEventListener("submit", (e) => {
    e.preventDefault();

    const nombre = document.getElementById("nombre").value;
    const docente = document.getElementById("docente").value;
    const aula = document.getElementById("aula").value;

    const nuevaAsignatura = {
        nombre,
        docente,
        aula,
    };

    // Obtener asignaturas del localStorage o inicializar un array vacío
    let asignaturas = JSON.parse(localStorage.getItem("asignaturas")) || [];

    // Agregar la nueva asignatura
    asignaturas.push(nuevaAsignatura);

    // Guardar el array actualizado en localStorage
    localStorage.setItem("asignaturas", JSON.stringify(asignaturas));

    // Cerrar el modal
    modal.style.display = "none";

    // Actualizar la lista de asignaturas
    mostrarAsignaturas();
});

// Función para mostrar las asignaturas guardadas
function mostrarAsignaturas() {
    const asignaturas = JSON.parse(localStorage.getItem("asignaturas")) || [];

    asignaturaList.innerHTML = "";
    asignaturas.forEach((asignatura) => {
        const asignaturaItem = document.createElement("div");
        asignaturaItem.classList.add("asignatura-item");

        asignaturaItem.innerHTML = `
      <span class="asignatura-titulo"><strong>Asignatura:</strong> ${asignatura.nombre}</span>
      <div class="buttons">
        <button class="btn">TAREAS</button>
        <button onclick="window.location.href='APUNTES.html'" class="btn btn-primary">
        APUNTES
        </button>        <button onclick="window.location.href='calificaciones.html'" class="btn">CALIFICACIONES</button>
        <button class="btn delete">ELIMINAR ASIGNATURA</button>
      </div>
    `;

        // Agregar el item de asignatura a la lista
        asignaturaList.appendChild(asignaturaItem);
    });
}

// Inicializar la lista de asignaturas
mostrarAsignaturas();

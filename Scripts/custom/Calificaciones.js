document.addEventListener("DOMContentLoaded", () => {
    const nombre = localStorage.getItem("asignaturaSeleccionada");
    const contenedor = document.getElementById("nombreAsignatura");
    contenedor.textContent = nombre || "Asignatura no seleccionada";
});
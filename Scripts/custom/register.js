document.addEventListener("DOMContentLoaded", () => {
    const form = document.getElementById("formUsuario");
    const mensajeDiv = document.getElementById("mensaje");

    form.addEventListener("submit", function (e) {
        e.preventDefault();

        const usuario = {
            NOMBRE: document.getElementById("nombre").value,
            CORREO: document.getElementById("correo").value,
            CONTRASENA: document.getElementById("contrasena").value,
            ROL: false
        };

        fetch("https://localhost:44334/api/Usuario/Insertar", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(usuario)
        })
            .then(response => response.text())
            .then(data => {
                mensajeDiv.innerText = data;
                form.reset();
                window.location.href = "Iniciar.html";
            })
            .catch(error => {
                mensajeDiv.innerText = "Error al guardar: " + error;
            });
    });
});

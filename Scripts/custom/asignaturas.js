document.addEventListener("DOMContentLoaded", () => {

    const form = document.getElementById("formAsignatura");

    const mensajeDiv = document.getElementById("mensaje");

    form.addEventListener("submit", function (e) {

        e.preventDefault();

        const asignatura = {

            NOMBRE: document.getElementById("nombre").value,

            DOCENTE: document.getElementById("docente").value,

            AULA: document.getElementById("aula").value

        };

        fetch("https://localhost:44334/api/Asignatura/Insertar", {

            method: "POST",

            headers: {

                "Content-Type": "application/json"

            },

            body: JSON.stringify(asignatura)

        })

            .then(response => response.text())

            .then(data => {

                mensajeDiv.innerText = data;

                form.reset();

            })

            .catch(error => {

                mensajeDiv.innerText = "Error al guardar: " + error;

            });

    });

});


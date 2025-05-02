document.addEventListener("DOMContentLoaded", () => {
    const btnLogin = document.getElementById("btnLogin");

    btnLogin.addEventListener("click", async () => {
        const correo = document.getElementById("correo").value.trim();
        const contrasena = document.getElementById("contrasena").value.trim();

        if (!correo || !contrasena) {
            alert("Por favor, ingresa correo y contraseña.");
            return;
        }

        try {
            const response = await fetch(`https://localhost:44334/api/Usuario/ConsultarXCorreo?correo=${correo}`);

            if (!response.ok) {
                throw new Error("Usuario no encontrado");
            }

            const data = await response.json();

            if (data.CONTRASENA === contrasena) {
                alert("Inicio de sesión exitoso");
                // Puedes guardar el usuario en localStorage si lo deseas:
                // localStorage.setItem("usuario", JSON.stringify(data));
                window.location.href = "Iniciar.html"; // Redirige al home
            } else {
                alert("Contraseña incorrecta");
            }

        } catch (error) {
            alert("Error al iniciar sesión: " + error.message);
        }
    });
});

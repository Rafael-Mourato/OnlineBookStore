document.addEventListener("DOMContentLoaded", () => {
    const html = document.documentElement; // Seleciona a tag <html>
    const themeToggle = document.getElementById("toggle-theme"); // ID correto do botão

    if (!themeToggle) {
        console.error("Elemento com ID 'toggle-theme' não encontrado.");
        return;
    }

    // Verifica o tema salvo no localStorage e aplica
    const savedTheme = localStorage.getItem("theme") || "light"; // Padrão: light
    html.setAttribute("data-bs-theme", savedTheme);
    themeToggle.textContent = savedTheme === "dark" ? "\uF5A1 Modo claro" : "\uF494 Modo Escuro";

    // Alterna o tema ao clicar no botão
    themeToggle.addEventListener("click", () => {
        const currentTheme = html.getAttribute("data-bs-theme");
        const newTheme = currentTheme === "light" ? "dark" : "light";
        html.setAttribute("data-bs-theme", newTheme);
        localStorage.setItem("theme", newTheme);
        themeToggle.textContent = newTheme === "dark" ? "\uF5A1 Modo claro" : "\uF494 Modo Escuro";
        console.log(`Tema alterado para: ${newTheme}`);
    });

    console.log(`Tema inicial: ${savedTheme}`);
});

/*************************************************************************************/

// Seleciona o botão pelo ID
const botaoTopo = document.getElementById('voltarAoTopo');

// Função para mostrar ou esconder o botão com base no scroll
window.addEventListener('scroll', () => {
    if (window.scrollY > 200) { // Se o scroll for maior que 200px
        botaoTopo.style.display = 'block'; // Exibe o botão
    } else {
        botaoTopo.style.display = 'none'; // Esconde o botão
    }
});

// Função para rolar suavemente ao topo quando o botão é clicado
botaoTopo.addEventListener('click', () => {
    window.scrollTo({
        top: 0,
        behavior: 'smooth' // Animação suave
    });
});

/*************************************************************************************/

const triggerTabList = document.querySelectorAll('#myTab button')
triggerTabList.forEach(triggerEl => {
    const tabTrigger = new bootstrap.Tab(triggerEl)

    triggerEl.addEventListener('click', event => {
        event.preventDefault()
        tabTrigger.show()
    })
})
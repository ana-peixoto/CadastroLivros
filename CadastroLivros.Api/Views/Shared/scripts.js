function loadPage(page) {
    const content = document.getElementById('content');

    switch (page) {
        case 'livros':
            content.innerHTML = `
                <h2>Lista de Livros</h2>
                <p>Aqui você pode gerenciar seus livros.</p>
                <!-- Adicione aqui a lógica para listar livros -->
            `;
            break;
        case 'autores':
            content.innerHTML = `
                <h2>Lista de Autores</h2>
                <p>Aqui você pode gerenciar seus autores.</p>
                <!-- Adicione aqui a lógica para listar autores -->
            `;
            break;
        case 'assuntos':
            content.innerHTML = `
                <h2>Lista de Assuntos</h2>
                <p>Aqui você pode gerenciar seus assuntos.</p>
                <!-- Adicione aqui a lógica para listar assuntos -->
            `;
            break;
        default:
            content.innerHTML = `
                <h2>Bem-vindo ao Cadastro de Livros!</h2>
                <p>Selecione uma opção no menu para começar.</p>
            `;
    }
}

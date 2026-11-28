window.scrollToSection = (id) => {
    const element = document.getElementById(id);
    if (element) {
        element.scrollIntoView({ behavior: 'smooth' });
    }
};

window.getTheme = () => {
    const saved = localStorage.getItem('portfolio-theme');
    return saved === 'dracula' ? 'dracula' : 'one-dark-pro';
};

window.setTheme = (theme) => {
    const normalized = theme === 'dracula' ? 'dracula' : 'one-dark-pro';
    document.documentElement.setAttribute('data-theme', normalized);
    localStorage.setItem('portfolio-theme', normalized);
};

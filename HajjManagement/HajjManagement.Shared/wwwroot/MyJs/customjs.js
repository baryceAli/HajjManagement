window.initializeTomSelect = (selector) => {
    if (document.querySelector(selector)) {
        new TomSelect(selector, {
            create: false,
            sortField: {
                field: "text",
                direction: "asc"
            }
        });
    }
};

window.triggerClick = (element) => {
    if (element) {
        element.click();
    }
};

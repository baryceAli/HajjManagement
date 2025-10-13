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


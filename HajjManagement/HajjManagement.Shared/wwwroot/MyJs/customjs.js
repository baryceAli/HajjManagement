window.initializeTomSelect = (selector) => {
    const el = document.querySelector(selector);
    if (el) {
        // destroy previous instance if exists
        if (el.tomselect) {
            el.tomselect.destroy();
        }

        new TomSelect(el, {
            create: false,
            sortField: { field: "text", direction: "asc" }
        });
    }
};


window.triggerClick = (element) => {
    if (element) {
        element.click();
    }
};


//************************************* *//
//            TomSelect Started             //
//************************************* *//
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
//************************************* *//
//            TomSelect Ended             //
//************************************* *//



window.triggerClick = (element) => {
    if (element) {
        element.click();
    }
};

//************************************* *//
//            Custome Modal             //
//************************************* *//
window.showModal = (id) => {
    const modalEl = document.querySelector(id);
    if (!modalEl) {
        console.error("Modal element not found:", id);
        return;
    }
    const modal = new bootstrap.Modal(modalEl);
    modal.show();
};

window.hideModal = (id) => {
    const modalEl = document.querySelector(id);
    if (!modalEl) {
        console.error("Modal element not found:", id);
        return;
    }
    const modal = bootstrap.Modal.getInstance(modalEl);
    if (modal) modal.hide();
};

//************************************* *//
//            Custome Modal             //
//************************************* *//



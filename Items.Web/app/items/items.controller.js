'use strict';
(function () {
    stockModule.controller("itemsController", itemsController);

    function itemsController(modalWindowFactory) {

        var self = this;

        //// ---------------- PUBLIC ----------------
        //// PUBLIC fields
        self.gridController = {};

        //// PUBLIC Methods
        // Method executed when a button inside the grid is clicked
        self.gridOnButtonClick = _gridOnButtonClick;

        // Method executed when the grid is initialized
        self.gridOnInitialized = _gridOnInitialized;

        //// ---------------- CODE TO RUN -----------

        //// ---------------- PRIVATE ---------------
        //// PRIVATE fields

        //// PRIVATE Functions - Public Methods Implementation	
        function _gridOnInitialized(controller) {
            self.gridController = controller;
        }

        function _gridOnButtonClick(sender, args) {
            console.log("button click" + args.button + " " + args.item.id);

            if (args.button == 'plus') {
                modalWindowFactory.show(args.item.name, "Custom button click = +");
            }
            else if (args.button == 'minus') {
                modalWindowFactory.show(args.item.name, "Custom button click = -");
            }
        }
  
    };
})();
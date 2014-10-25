stockModule.controller("cellEditorController", cellEditorController);

function cellEditorController($scope) {

    'use strict';
    var self = this;

    //// ---------------- PUBLIC -----------------
    //// PUBLIC fields

    self.keyUpEvent = $scope.keyUpEvent;
    self.column = $scope.column;
    self.item = $scope.item;
    self.today = new Date();

    self.datePickerOpen = false;
    self.openDatePicker = _openDatePicker;
    
    self.fireKeyUpEvent = _fireKeyUpEvent;

    //// PUBLIC Methods


    //// ---------------- CODE TO RUN ------------


    //// ---------------- PRIVATE ----------------

    //// PRIVATE fields

    //// PRIVATE Functions - Public Methods Implementation
    function _fireKeyUpEvent(args, item) {
        // call method with parameters
        self.keyUpEvent()(args, item);
    };

    function _openDatePicker($event) {
        $event.preventDefault();
        $event.stopPropagation();

        self.datePickerOpen = true;
    };

    //// PRIVATE Functions

};

stockModule.directive('cellEditor', function () {
    return {
        //	'A' - only matches attribute name
        //	'E' - only matches element name
        //	'C' - only matches class name
        restrict: 'A',
        // Replace the element that contains the attribute
        replace: true,
        // scope = false, parent scope
        // scope = true, get new scope
        // scope = {...}, isolated scope>
        //		1. "@"   ( Text binding / one-way )
        //      2. "="   ( Model binding / two-way  )
        //      3. "&"   ( Method binding  )
        scope: {
            column: "=",        // object binding
            item: "=",          // object binding
            keyUpEvent: "&",    // method binding
        },
        // view
        templateUrl: '/app/directives/crud.grid/cell.editor/cell.editor.view.html',
        // controller
        controller: "cellEditorController as cellEditorCtrl"
    };
});
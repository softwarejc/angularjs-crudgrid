stockModule.factory('modalWindowFactory', function ($modal) {

    var modalWindowController = _modalWindowController;

    return {

        // Show a modal window with the specified title and msg
        show: function (title, msg, confirmCallback, cancelCallback) {

            // Show window
            var modalInstance = $modal.open({
                templateUrl: 'app/templates/modal-window.view.html',
                controller: modalWindowController,
                size: 'sm',
                resolve: {
                    title: function () {
                        return title;
                    },
                    body: function () {
                        return msg;
                    }
                }
            });

            // Register confirm and cancel callbacks
            modalInstance.result.then(
                // if any, execute confirm callback
                function() {
                    if (confirmCallback != undefined) {
                        confirmCallback();
                    }
                },
                // if any, execute cancel callback
                function () {
                    if (cancelCallback != undefined) {
                        cancelCallback();
                    }
                });
        }
    };


    // Internal controller used by the modal window
    function _modalWindowController($scope, $modalInstance, title, body) {
        $scope.title = "";
        $scope.body = "";

        // If specified, fill window title and message with parameters
        if (title) {
            $scope.title = title;
        }
        if (body) {
            $scope.body = body;
        }

        $scope.confirm = function () {
            $modalInstance.close();
        };

        $scope.cancel = function () {
            $modalInstance.dismiss();
        };
    };


});

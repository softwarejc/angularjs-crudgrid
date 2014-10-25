(function () {
    'use strict';

    // module definition
    stockModule.factory("reactiveFactory", function reactiveFactory() {
        return {
            // Execute an action after a period of time without calls
            getThrottle: _createThrottle
        };

        function _createThrottle(delay) {
            var throttleTimer = null;
            var throttleDelay = delay;

            if (!throttleDelay) {
                // use default value 250ms
                throttleDelay = 250;
            }

            return {
                run: function(action) {
                    return function() {
                        clearTimeout(throttleTimer);

                        throttleTimer = setTimeout(function() {
                            // execute action
                            action.apply();

                            // dispose timer
                            throttleTimer = null;
                        }, throttleDelay);
                    }();
                }
            };
        }

    });
})();



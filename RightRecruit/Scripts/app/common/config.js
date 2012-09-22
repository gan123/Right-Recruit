define('config',
    ['toastr'],
    function(toastr) {
        var toasts = {
                changesPending: 'Please save or cancel your changes before leaving the page.',
                errorSavingData: 'Data could not be saved. Please check the logs.',
                errorGettingData: 'Could not retrieve data.  Please check the logs.',
                invalidRoute: 'Cannot navigate. Invalid route',
                retreivedData: 'Data retrieved successfully',
                savedData: 'Data saved successfully'
            },
            logger = toastr,
            init = function() {
                toastr.options = {
                    timeOut: 2000,
                    positionClass: 'toast-bottom-right'
                };
            };

        init();

        return {
            toasts: toasts,
            logger: logger
        };
    });
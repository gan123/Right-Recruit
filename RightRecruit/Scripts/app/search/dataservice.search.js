define('dataservice.search',
    ['amplify'],
    function (amplify) {
        var init = function() {
            amplify.request.define('client-quicksearch', 'ajax', {
                url: '/rr/clients/quicksearch',
                dataType: 'json',
                type: 'POST',
            });
            
            amplify.request.define('recruiter-quicksearch', 'ajax', {
                url: '/rr/recruiters/quicksearch',
                dataType: 'json',
                type: 'POST',
            });
        };

        return {
            init: init
        };
    });
define('dataservice.client',
    ['amplify'],
    function(amplify) {
        var init = function() {
            amplify.request.define('clients-list', 'ajax', {
                url: '/rr/clients/search',
                dataType: 'json',
                type: 'POST',
                contentType: 'application/json; charset=utf-8'
            });
            
            amplify.request.define('client-create', 'ajax', {
                url: '/rr/clients/create',
                dataType: 'json',
                type: 'POST',
                contentType: 'application/json; charset=utf-8'
            });
        };

        init();

        return {
            init: init
        };
    });
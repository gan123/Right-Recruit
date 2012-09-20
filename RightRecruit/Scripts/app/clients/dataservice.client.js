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
        };

        var search = function(data, callbacks) {
            return amplify.request({
                resourceId: 'clients-list',
                data: data,
                success: callbacks.success
            });
        };

        init();
        
        return {
            search: search
        }
    });
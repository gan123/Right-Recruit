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

        var search = function(data, callbacks) {
            return amplify.request({
                resourceId: 'clients-list',
                data: data,
                success: callbacks.success
            });
        };
        
        var create = function (data, callbacks) {
            console.log(data);
            return amplify.request({
                resourceId: 'client-create',
                data: ko.toJSON(data),
                success: callbacks.success,
                error: callbacks.error
            });
        };

        init();
        
        return {
            search: search,
            create: create
        }
    });
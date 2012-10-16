define('dataservice.admin',
    ['amplify'],
    function(amplify) {
        var init = function() {
            amplify.request.define('personalize-get', 'ajax', {
                url: '/rr/admin/personalize/get',
                type: 'GET'
            });
            
            amplify.request.define('personalize-save', 'ajax', {
                url: '/rr/admin/personalize/save',
                dataType: 'json',
                type: 'POST'
            });
        };

        var getPersonalization = function(callbacks) {
            return amplify.request({
                resourceId: 'personalize-get',
                success: callbacks.success,
                error: callbacks.error
            });
        };
        
        var savePersonalization = function (data, callbacks) {
            return amplify.request({
                resourceId: 'personalize-save',
                data: data,
                success: callbacks.success,
                error: callbacks.error
            });
        };

        init();

        return {
            getPersonalization: getPersonalization,
            savePersonalization: savePersonalization
        };
    });
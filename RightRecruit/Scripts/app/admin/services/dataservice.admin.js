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
                type: 'POST',
                contentType: 'application/json; charset=utf-8'
            });
        };

        return {
            init: init
        };
    });
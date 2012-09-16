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

        var clientsSearch = function(data, success) {
            return amplify.request({
                resourceId: 'client-quicksearch',
                data: data,
                success: success
            });
        };
        
        var recruitersSearch = function (data, success) {
            return amplify.request({
                resourceId: 'recruiter-quicksearch',
                data: data,
                success: success
            });
        };

        init();
        
        return {
            clientsSearch: clientsSearch,
            recruitersSearch: recruitersSearch
        };
    });
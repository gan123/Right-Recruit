define('vm.inbox',
    ['ko', 'jquery', 'vm.client.quicksearch'],
    function (ko, $, searchClient) {
        var open = ko.observable('Open (10)'),
            inprogress = ko.observable(),
            onhold = ko.observable(),
            closed = ko.observable(),
            cancelled = ko.observable(),
            clientQuickSearch = searchClient;
        
        return {
            open: open,
            inprogress: inprogress,
            onhold: onhold,
            closed: closed,
            cancelled: cancelled,
            clientQuickSearch: clientQuickSearch
        };
    });
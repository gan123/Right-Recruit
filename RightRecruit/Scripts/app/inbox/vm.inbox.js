define('vm.inbox',
    ['ko'],
    function (ko) {
        var
            open = ko.observable('Open (10)'),
            inprogress = ko.observable(),
            onhold = ko.observable(),
            closed = ko.observable(),
            cancelled = ko.observable();

        return {
            open: open,
            inprogress: inprogress,
            onhold: onhold,
            closed: closed,
            cancelled: cancelled
        };
    });
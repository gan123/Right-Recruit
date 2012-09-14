$(function () {
    $("#inbox").attr('class', 'menuitem active');
    $(".statusItem").click(function () {
        $(this).toggleClass('selectedStatus');
    });

    $("#date").datepicker({
        autoSize: true,
        showOn: "button",
        buttonImage: '/rr/Content/images/calendar_blue.png',
        buttonImageOnly: true
    });

    requirejs(['vm.inbox', 'binder'], load);

    function load() {
        require(['vm.inbox', 'binder'], function (vm, b) {
            b.bind(vm, "#inbox-view");
        });
    }
});
$(function () {
    requirejs(['vm.clients.create', 'binder'], load);

    $("#cancel").click(function () {
        window.location = '/rr/clients';
    });

    function load() {
        require(['vm.clients.create', 'binder'], function (vm, b) {
            console.log('in');
            b.bind(vm, "#clients-create");
        });
    }
})
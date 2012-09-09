$(function () {
    $("#inbox").attr('class', 'menuitem active');
    $(".statusItem").click(function () {
        $(this).toggleClass('selectedStatus');
    });

    $("#date").datepicker({ autoSize: true });
});
$(document).ready(function () {
    $('.table-data').DataTable({
        'aoColumnDefs': [{
            'bSortable': false,
            'aTargets': [-1]
        }]
    });

    $('.table-data-last-active').DataTable();
});
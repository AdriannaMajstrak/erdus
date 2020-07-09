"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var DataTableSettings = /** @class */ (function () {
    function DataTableSettings() {
        this.language = {
            lengthMenu: "Wyświetl _MENU_ rekordów na stronę",
            zeroRecords: "Nic nie znaleziono",
            info: "Wyświetlono _PAGE_  stronę z _PAGES_",
            infoEmpty: "Brak danych",
            infoFiltered: "(wyfiltrowano z _MAX_ wszystkich rekodrów)",
            search: "Szukaj:",
            paginate: {
                "first": "Pierwsza",
                "last": "Ostatnia",
                "next": "Następna",
                "previous": "Poprzednia"
            }
        };
        this.columns = [
            { "orderable": true },
            { "orderable": true },
            { "orderable": true },
            { "orderable": true },
            { "orderable": true },
            { "orderable": false }
        ];
        this.order = [[2, "desc"]];
    }
    return DataTableSettings;
}());
exports.DataTableSettings = DataTableSettings;
//# sourceMappingURL=datatableSettings.js.map
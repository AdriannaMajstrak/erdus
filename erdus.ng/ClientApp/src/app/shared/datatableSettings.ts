export class DataTableSettings implements DataTables.Settings {
  language = {
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
  }

  columns = [
    { "orderable": true },
    { "orderable": true },
    { "orderable": true },
    { "orderable": true },
    { "orderable": true },
    { "orderable": false }
  ]

  order = [[2, "desc"]]

 
}

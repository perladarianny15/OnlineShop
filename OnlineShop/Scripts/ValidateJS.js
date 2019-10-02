function ProductSelect(id) {
    var data = { id: id };
    $.ajax({
        url: 'Products/GetSelectedItem',
        type: 'POST',
        dataType: 'json',
        contentType: 'application/json',
        data: JSON.stringify(data)
    });
}
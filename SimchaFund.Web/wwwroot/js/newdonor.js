$(() => {
    $("#new-donor").on('click', function () {
        $("#newContributorModal").modal();
    }); 

    $('.deposit').on('click', function () {
        //console.log('hello')
        const id = $(this).data('donorid');
        $("#donorid").val(id);
        console.log(id);
        $("#depositModal").modal();
    }); 

    $('.edit').on('click', function () {
        
        const id = $(this).data('id');
        const firstName = $(this).data('fr');
        const lastName = $(this).data('la');
        const cellNumber = $(this).data('cl');
        console.log(id);        

        $("#firstname").val(firstName);
        $("#lastname").val(lastName);
        $("#cell").val(cellNumber);
        $("#id").val(id);
        $("#editContributorModal").modal();
    });
    
});
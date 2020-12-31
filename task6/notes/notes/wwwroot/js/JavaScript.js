
var addNote = true;
var noteId = 0;
var sizeX = 0;
var sizeY = 0;


$('html').on('click',async function (e) {
    if (addNote) {
        noteId = Math.floor(Math.random() * Math.floor(0xffffff));
        var id = 'note' + noteId;

        var img = $(
           
        '<div class="NOTE" id="' + id + '" style ="position: absolute">' +
            '<div class="noteHeader">' +
            '<div class="buttons">' +
            ' <div id="yellow">' +
            '    <button onclick="fillYellow(' + noteId+')" class="button yellow"></button>' +
            '</div>' +
            ' <div id="blue">' +
            '    <button onclick="fillBlue(' + noteId +')" class="button blue"></button>' +
            '</div>' +
            ' <div id="pink">' +
            '     <button onclick="fillPink(' + noteId +')" class="button pink"></button>' +
            ' </div>' +
            ' </div>' +
            '<div id="exit">' +
            '     <button  onclick="deleteNote()" class="btn"><i class="fas fa-skull-crossbones" style="color:red"></i></button>' +
            ' </div>' +
            '</div>' +
            ' <div class="noteBody">' +
            '  <div class="header">' +
            '     <p><textarea></textarea></p>' +
            ' </div>' +
            ' <div class="content">' +
            '     <textarea></textarea>' +
            ' </div>' +
            ' </div>' +
       ' <div>' +
            '    <button  onclick="saveNote()" class="btn" ><i class="fas fa-save" style="color:green"></i></button>' +
            ' </div>' +
    '</div>' 
        );
        $("body").append(img.offset({ top: e.pageY - sizeY, left: e.pageX - sizeX }).draggable().resizable());
        $('.content textarea').resizable();
        //console.log($('.note').height());
       //  sizeY += $('.note').height()
         //sizeX += $('.note').width()
       

    }
    addNote = true;
});


$('.note').draggable().resizable();


$('body').on('click', function (e) {
    addNote = false;
    let id = findNoteIdbyEvent(e);
    $('#' + id).offset({ top: 0, left: 0 });
});


//async function establishNoteId() {
//    let response =  await fetch('/note', {
//        method: 'GET',
//        headers: { 'Accept': 'application/json', 'Content-Type': 'application/json' }
//    })
//    if (response.ok) {
//        let notes = await response.json();
//        let count = parseInt(++noteId + notes.length,10);
//        return count;
//    } else {
//        return ++noteId;
//    }
//}

function fillYellow(id) {
    id = '#note'+id
    $(id).css("background-color", "yellow");
}
function fillBlue(id) {
    id = '#note' + id
    $(id).css("background-color", "blue");
}
function fillPink(id) {
    id = '#note' + id
    $(id).css("background-color", "pink");
}







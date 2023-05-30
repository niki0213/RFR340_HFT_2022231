let books = [];
let connection;
let bookidupdate = -1;


getdata();
setupSignalR();


function setupSignalR() {
        connection = new signalR.HubConnectionBuilder()
            .withUrl("http://localhost:4738/hub")
            .configureLogging(signalR.LogLevel.Information)
            .build();

        connection.on("BookCreated", (user, message) => {
            getdata();
        });

        connection.on("BookDeleted", (user, message) => {
            getdata();
        });

        connection.on("BookUpdated", (user, message) => {
            getdata();
        });

        connection.onclose(async () => {
            await start();
        });
        start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};


async function getdata() {
    await fetch('http://localhost:4738/book')
        .then(x => x.json())
        .then(y => {
            books = y;
/*            consol.log(books);*/
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    books.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.bookID + "</td><td>"
            + t.title + "</td><td>"
            + t.author + "</td><td>"
            + `<button type="button" onclick="remove(${t.bookID})"/> Delete`
            + `<button type="button" onclick="showupdate(${t.bookID})"/> Update`
            + "</td></tr>";
    });
}

function remove(id){
    fetch('http://localhost:4738/book/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null})
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function showupdate(id) {
    document.getElementById('titleupdate').value = books.find(t => t['bookID'] == id)['title'];
    document.getElementById('authorupdate').value = books.find(t => t['bookID'] == id)['author'];
    document.getElementById('publisherupdate').value = books.find(t => t['bookID'] == id)['publisherID'];
    bookidupdate = id;
}

function update() {
    let t = document.getElementById('titleupdate').value;
    let a = document.getElementById('authorupdate').value;
    let p = document.getElementById('publisherupdate').value;
    fetch('http://localhost:4738/book', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            { bookID: bookidupdate, title: t, author: a, publisherID: p }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}
function create() {
    let t = document.getElementById('booktitle').value;
    let a = document.getElementById('bookauthor').value;
    let p = document.getElementById('publisherid').value;
    fetch('http://localhost:4738/book',{
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ title: t, author: a, publisherID: p })})
        .then(response => response)
        .then(data =>
        {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}




let publishers = [];
let connection;
let idu = -1;


getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:4738/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("PublisherCreated", (user, message) => {
        getdata();
    });

    connection.on("PublisherDeleted", (user, message) => {
        getdata();
    });

    connection.on("PublisherUpdated", (user, message) => {
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
    await fetch('http://localhost:4738/publisher')
        .then(x => x.json())
        .then(y => {
            publishers = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    publishers.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.publisherID + "</td><td>"
            + t.name + "</td><td>"
        + `<button type="button" onclick="remove(${t.publisherID})"/> Delete`
        + `<button type="button" onclick="showupdate(${t.publisherID})"/> Update`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:4738/publisher/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function showupdate(id) {
    document.getElementById('nameu').value = publishers.find(t => t['publisherID'] == id)['name'];
    idu = id;
}

function update() {
    let n = document.getElementById('nameu').value;
    fetch('http://localhost:4738/publisher', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            { publisherID: idu, name: n}),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}
function create() {
    let n = document.getElementById('name').value;
    fetch('http://localhost:4738/publisher', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ name: n})
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}




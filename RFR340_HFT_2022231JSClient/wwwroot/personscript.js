let persons = [];
let connection;
let personidu = -1;


getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:4738/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("PersonCreated", (user, message) => {
        getdata();
    });

    connection.on("PersonDeleted", (user, message) => {
        getdata();
    });

    connection.on("PersonUpdated", (user, message) => {
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
    await fetch('http://localhost:4738/person')
        .then(x => x.json())
        .then(y => {
            persons = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    persons.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.personID + "</td><td>"
            + t.name + "</td><td>"
            + t.phone + "</td><td>"
        + `<button type="button" onclick="remove(${t.personID})"/> Delete`
        + `<button type="button" onclick="showupdate(${t.personID})"/> Update`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:4738/person/' + id, {
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
    document.getElementById('nameu').value = persons.find(t => t['personID'] == id)['name'];
    document.getElementById('phoneu').value = persons.find(t => t['personID'] == id)['phone'];
    personidu = id;
}

function update() {
    let n = document.getElementById('nameu').value;
    let p = document.getElementById('phoneu').value;
    fetch('http://localhost:4738/person', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            { personID: personidu, name: n, phone: p }),
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
    let p = document.getElementById('phone').value;
    fetch('http://localhost:4738/person', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ name: n, phone: p })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}




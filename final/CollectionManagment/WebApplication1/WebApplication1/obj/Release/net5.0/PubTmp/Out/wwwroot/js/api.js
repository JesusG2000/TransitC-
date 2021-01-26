async function isUserLoggedIn() {
    return await fetch("/getUserByToken", {
        method: "POST",
        headers: {
            "Accept": "application/json", "Content-Type": "application/json",
            "Authorization": "Bearer " + localStorage['jwt']
        }
    });
}

async function registerUser(data) {
    return await fetch("/registration", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(data)
    });
}
async function isUserRegistered(data) {
    return await fetch("/isRegistered", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(data)
    });
}
async function loginUser(data) {
    return await fetch("/login", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(data)
    });
}

async function init() {
    await fetch("/init",
        {
            method: "GET",
            headers: { "Accept": "application/json", "Content-Type": "application/json" }
        });
}

async function createCollection(data) {
    return await fetch("/createCollection", {
        method: "POST",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
            "Authorization": "Bearer " + localStorage['jwt']
        },
        body: JSON.stringify(data)
});
}

async function createField(data) {
    return await fetch("/createField", {
        method: "POST",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
            "Authorization": "Bearer " + localStorage['jwt']
        },
        body: JSON.stringify(data)
    });
}
async function isCollectionExist(data) {
    return await fetch("/isCollectionExist", {
        method: "POST",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
            "Authorization": "Bearer " + localStorage['jwt']
        },
        body: JSON.stringify(data)
    });
}
async function isFieldExist(data) {
    return await fetch("/isFieldExist", {
        method: "POST",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
            "Authorization": "Bearer " + localStorage['jwt']
        },
        body: JSON.stringify(data)
    });
}
async function getCollectionsByType(data) {
    return await fetch("/getCollectionsByType/" + data, {
        method: "GET",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
          
        }
       
    });
}
async function getCollectionsByUserIdAndType(userId , data) {
    return await fetch("/getCollectionsByUserIdAndType/" + userId+'/'+data, {
        method: "GET",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
            "Authorization": "Bearer " + localStorage['jwt']
        }
       
    });
}
async function getUserCollectionFields(collectionName) {
    return await fetch("/getUserCollectionFields/" + collectionName, {
        method: "GET",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
            "Authorization": "Bearer " + localStorage['jwt']
        }
       
    });
}
async function removeCollection(id) {
    return await fetch("/removeCollection/"+id, {
        method: "DELETE",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
            "Authorization": "Bearer " + localStorage['jwt']
        }
    });
}


let cursorinfos = [];
document.getElementById("trackingbase").addEventListener("mousemove", trackcursor);
document.getElementById("senddatabtn").addEventListener("click", senddata)
function trackcursor(event) {
    console.log(cursorinfos.length);
    cursorinfos.push({ x: event.clientX, y: event.clientY, time: new Date().toJSON() });
}

async function senddata() {
    try {
        console.log(cursorinfos);
        var response = await axios.post("http://localhost:8080/api/cursorinfos/createrange", cursorinfos);
        return response.data;
    } catch (e) {
        console.error(e);
    }
}


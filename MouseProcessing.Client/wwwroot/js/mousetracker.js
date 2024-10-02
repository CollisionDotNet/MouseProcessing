let cursorinfos = [];
document.getElementById("trackingbase").addEventListener("mousemove", trackcursor);
document.getElementById("senddatabtn").addEventListener("click", senddata)
function trackcursor(event) {
    cursorinfos.push({ x: event.clientX, y: event.clientY, time: new Date().toJSON() });
}

function senddata() {
    axios.post("http://localhost:8080/api/cursorinfos/createrange", cursorinfos)
        .then(res => res.status === 200 ? alert("Данные успешно отправлены!") : (alert("Произошла ошибка!"), console.log(res)))
        .catch(err => (alert("Произошла ошибка!"), console.log(err)));
}


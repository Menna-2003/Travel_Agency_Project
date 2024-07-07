let right = document.getElementsByClassName("right")[0];
let left = document.getElementsByClassName("left")[0];
let content = document.getElementsByClassName("content")[0];
let bike = document.querySelector(".ReservationContainer img.bike");
let bikebtn = document.querySelector(".ReservationContainer .btn.bike");
let car = document.querySelector(".ReservationContainer img.car");
let carbtn = document.querySelector(".ReservationContainer .btn.car");
let title = document.querySelector(".ReservationContainer .title");

carbtn.addEventListener("click", (e) => {
    carbtn.classList.add("active");
    bikebtn.classList.remove("active");
    bike.style.visibility = "hidden";
    car.style.visibility = "visible";
    title.innerHTML = "Book Now Car";
});
bikebtn.addEventListener("click", (e) => {
    bikebtn.classList.add("active");
    carbtn.classList.remove("active");
    car.style.visibility = "hidden";
    bike.style.visibility = "visible";
    title.innerHTML = "Book Now Bike";
});

if (window.innerWidth > 780) {
    width = -1 * (content.offsetWidth - 400);
    let leftspace = 0;
    right.addEventListener("click", (e) => {
        if (leftspace >= width) {
            leftspace -= 320;
            console.log(leftspace);
            let variable = `${leftspace}px`;
            content.style.left = variable;
        }
    });

    left.addEventListener("click", (e) => {
        if (leftspace !== 0) {
            leftspace += 320;
            console.log(leftspace);
            let variable = `${leftspace}px`;
            content.style.left = variable;
        }
    });
} else {
    width = -1 * (content.offsetWidth - 800);
    let leftspace = 0;
    right.addEventListener("click", (e) => {
        if (leftspace >= width) {
            leftspace -= 260;
            console.log(leftspace);
            let variable = `${leftspace}px`;
            content.style.left = variable;
        }
    });

    left.addEventListener("click", (e) => {
        if (leftspace !== 0) {
            leftspace += 260;
            console.log(leftspace);
            let variable = `${leftspace}px`;
            content.style.left = variable;
        }
    });
}

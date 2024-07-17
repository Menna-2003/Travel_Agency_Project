// *************  user details   ********************

let minus1 = document.getElementsByClassName("minus")[0];
let plus1 = document.getElementsByClassName("plus")[0];
let count1 = document.getElementsByClassName("count")[0];

minus1.addEventListener("click", (e) => {
    if (count1.value != 0 )
        count1.value = Number(count1.value) - 1;
});
plus1.addEventListener("click", (e) => {
    count1.value = Number(count1.value) + 1;
});

let minus2 = document.getElementsByClassName("minus")[1];
let plus2 = document.getElementsByClassName("plus")[1];
let count2 = document.getElementsByClassName("count")[1];

minus2.addEventListener("click", (e) => {
    if (count2.value != 0)
        count2.value = Number(count2.value) - 1;
});
plus2.addEventListener("click", (e) => {
    count2.value = Number(count2.value) + 1;
});

let minus3 = document.getElementsByClassName("minus")[2];
let plus3 = document.getElementsByClassName("plus")[2];
let count3 = document.getElementsByClassName("count")[2];

minus3.addEventListener("click", (e) => {
    if (count3.value != 0)
        count3.value = Number(count3.value) - 1;
});
plus3.addEventListener("click", (e) => {
    count3.value = Number(count3.value) + 1;
});
console.log("jsakjdka");


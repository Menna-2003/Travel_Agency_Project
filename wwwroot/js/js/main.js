let TotalPrice = document.getElementById("TotalPrice");
let TotalpriceVar = 0;

let minus1 = document.getElementById("minus1");
let plus1 = document.getElementById("plus1");
let count1 = document.getElementById("AdultsInput");
let AdultsCounter = document.getElementById("AdultsCounter");
let AdultsPrice = document.getElementById("AdultsPrice");

minus1.addEventListener("click", (e) => {
    if (count1.value != 0) count1.setAttribute("value", Number(count1.value) - 1);

    AdultsCounter.innerText = count1.value;
    let price = Number(count1.value) * Number(AdultsPrice.getAttribute("price"));
    AdultsPrice.innerText = `€${price}`;

    TotalpriceVar -= Number(AdultsPrice.getAttribute("price"));
    TotalPrice.innerText = `€${TotalpriceVar}`;
});
plus1.addEventListener("click", (e) => {
    count1.setAttribute("value", Number(count1.value) + 1);
    AdultsCounter.innerText = count1.value;

    let price = Number(count1.value) * Number(AdultsPrice.getAttribute("price"));
    AdultsPrice.innerText = `€${price}`;

    TotalpriceVar += Number(AdultsPrice.getAttribute("price"));
    TotalPrice.innerText = `€${TotalpriceVar}`;
});

let minus2 = document.getElementById("minus2");
let plus2 = document.getElementById("plus2");
let count2 = document.getElementById("ChildTickets");
let ChildrenCounter = document.getElementById("ChildrenCounter");
let ChildrenPrice = document.getElementById("ChildrenPrice");

minus2.addEventListener("click", (e) => {
    if (count2.value != 0) count2.setAttribute("value", Number(count2.value) - 1);

    ChildrenCounter.innerText = count2.value;
    let price2 = Number(count2.value) * Number(ChildrenPrice.getAttribute("price"));
    ChildrenPrice.innerText = `€${price2}`;
    console.log(count2.value);

    TotalpriceVar -= Number(ChildrenPrice.getAttribute("price"));
    TotalPrice.innerText = `€${TotalpriceVar}`;
});

plus2.addEventListener("click", (e) => {
    count2.setAttribute("value", Number(count2.value) + 1);
    ChildrenCounter.innerText = count2.value;
    let price2 = Number(count2.value) * Number(ChildrenPrice.getAttribute("price"));
    ChildrenPrice.innerText = `€${price2}`;
    console.log(count2.value);

    TotalpriceVar += Number(ChildrenPrice.getAttribute("price"));
    TotalPrice.innerText = `€${TotalpriceVar}`;
});

let minus3 = document.getElementById("minus3");
let plus3 = document.getElementById("plus3");
let count3 = document.getElementById("InfantTickets");
let InfantCounter = document.getElementById("InfantCounter");
let InfantPrice = document.getElementById("InfantPrice");

minus3.addEventListener("click", (e) => {
    if (count3.value != 0) count3.setAttribute("value", Number(count3.value) - 1);
    InfantCounter.innerText = count3.value;
    let price3 = Number(count3.value) * Number(InfantPrice.getAttribute("price"));
    InfantPrice.innerText = `€${price3}`;
    console.log(count3.value);

    TotalpriceVar -= Number(InfantPrice.getAttribute("price"));
    TotalPrice.innerText = `€${TotalpriceVar}`;
});
plus3.addEventListener("click", (e) => {
    count3.setAttribute("value", Number(count3.value) + 1);
    InfantCounter.innerText = count3.value;
    let price3 = Number(count3.value) * Number(InfantPrice.getAttribute("price"));
    InfantPrice.innerText = `€${price3}`;
    console.log(count3.value);

    TotalpriceVar += Number(InfantPrice.getAttribute("price"));
    TotalPrice.innerText = `€${TotalpriceVar}`;
});

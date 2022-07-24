let patientId;
const tbl = document.querySelector("table");
const start_input = document.getElementById("startDate");
const end_input = document.getElementById("endDate");
const city_input = document.getElementById("city");
const location_input = document.getElementById("location");
const list = document.querySelector(".list");
const filter_city = document.getElementById("filter");

class InfoLocation {
    constructor(startDate, endDate, city, location) {
        this.startDate = startDate;
        this.endDate = endDate;
        this.city = city;
        this.location = location;
    }
}

class Person {
    constructor(id, arr = []) {
        this.id = id;
        this.arr = arr;
    }
}

const validPatientId = () => {
    if (patientId.length === 9 && parseInt(patientId) == patientId) {
        return true;
    }
    alert("patient id isn't valid, you need enter id with nine digits");
    return false;
}

const changeId = () => {
    patientId = document.getElementById("patientId");
    patientId = patientId?.value;
    getAllInfoForPatient();
}

const resetTable = () => {
    tbl.innerHTML = '';
    let tr = document.createElement('tr');
    let th_start = document.createElement('th');
    th_start.innerHTML = 'Start Date';
    let th_end = document.createElement('th');
    th_end.innerHTML = 'End Date';
    let th_city = document.createElement('th');
    th_city.innerHTML = 'City';
    let th_location = document.createElement('th');
    th_location.innerHTML = 'Location';
    let th_rem = document.createElement('th');
    th_rem.innerHTML = '🗑';
    tr.append(th_start);
    tr.append(th_end)
    tr.append(th_city);
    tr.append(th_location);
    tr.append(th_rem);
    tbl.append(tr);
}

if (tbl !== null) {
    resetTable();
}

const formatDate = (date) => {
    let d = new Date(date);
    return `${d.getDate()}/${d.getMonth()}/${d.getFullYear()} ${d.getHours() < 10 ? '0' + d.getHours() : d.getHours()}:${d.getMinutes() < 10 ? '0' + d.getMinutes() : d.getMinutes()}`;
}

const formatTime = (date) => {
    let d = new Date(date);
    return `${d.getHours() < 10 ? '0' + d.getHours() : d.getHours()}:${d.getMinutes() < 10 ? '0' + d.getMinutes() : d.getMinutes()}`;
}

const getAllInfoForPatient = () => {
    if (validPatientId()) {
        resetTable();
        fetch('http://localhost:5056/api/Location/GetLocationById/' + patientId, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
            },
        })
            .then(response => response.json())
            .then(data => {
                data.forEach(element => {
                    tr = document.createElement('tr');
                    let td_start = document.createElement('td');
                    td_start.innerHTML = formatDate(element.startDate);
                    let td_end = document.createElement('td');
                    td_end.innerHTML = formatDate(element.endDate);
                    let td_city = document.createElement('td');
                    td_city.innerHTML = element.city;
                    let td_location = document.createElement('td');
                    td_location.innerHTML = element.location;
                    let td_rem = document.createElement('td');
                    td_rem.innerHTML = '✖';
                    td_rem.addEventListener("click", () => {
                        fetch('http://localhost:5056/api/Location/' + patientId, {
                            method: 'DELETE',
                            headers: {
                                'Content-Type': 'application/json',
                            },
                            body: JSON.stringify(element),
                        })
                            .then(() => {
                                console.log('Success');
                                getAllInfoForPatient();
                            })
                            .catch((error) => {
                                console.error('Error:', error);
                            });
                        
                    });
                    tr.append(td_start);
                    tr.append(td_end)
                    tr.append(td_city);
                    tr.append(td_location);
                    tr.append(td_rem);
                    tbl.append(tr);
                    console.log('Success:', data);
                })
            })
            .catch((error) => {
                console.error('Error:', error);
            });;
    }
}

const add = () => {
    if (validPatientId()) {
        if (start_input.value === '' || end_input.value === '' || location_input.value === '' || city_input.value === '') {
            alert("you need to complete all the fields!");
        }
        else {
            let new_info_location = new InfoLocation(start_input.value, end_input.value, city_input.value, location_input.value);
            fetch('http://localhost:5056/api/Location/' + patientId, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(new_info_location),
            })
                .then(() => {
                    console.log('Success');
                    start_input.value = '';
                    end_input.value = '';
                    city_input.value = '';
                    location_input.value = '';
                    getAllInfoForPatient();
                })
                .catch((error) => {
                    console.error('Error:', error);
                });
        }

    }
}

const loadingData = () => {
    fetch('http://localhost:5056/api/Location/' + filter_city?.value, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
        },
    })
        .then(response => response.json())
        .then(data => {
            if (list !== null) {
                list.innerHTML = '';
            }
            data.forEach(x => {
                let li = document.createElement('li');
                li.innerHTML = `${formatDate(x.startDate)} - ${formatTime(x.endDate)} | ${x.city} | ${x.location}`;
                list.append(li);
            });
            console.log('Success:', data);
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

loadingData();

if (filter_city != null) {
    filter_city.onkeyup = () => {
        loadingData();
    }
}



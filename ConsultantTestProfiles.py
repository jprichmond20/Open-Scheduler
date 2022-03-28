import json
import uuid

from faker import Faker
import random

# dictionary = {
#     "days":[[],[],[],[],[],[],[]],
#     "major": [],
#     "maj": "",
#     "min": "",
#     "yearsWorked": 0,
#     "hoursPer": 0,
#     "first": "",
#     "last": "",
#     "userID": "",
#     "director": False
# }

majMin = ["Accounting",
            "African American Studies",
            "American Studies",
            "Art",
            "Art History",
            "Asian Studies",
            "Biochemistry",
            "Biology",
            "Business Administration",
            "Chemistry",
            "Communication Studies",
            "Computer Science",
            "Creative Writing",
            "Data Science",
            "Economics",
            "Education",
            "English",
            "English as a Second Language - ESL",
            "Environmental Science",
            "Environmental Studies",
            "Film Studies",
            "French",
            "French Studies",
            "General Science",
            "History",
            "Interdisciplinary Studies",
            "International Business",
            "International Economics",
            "International Studies",
            "Kinesiology",
            "Literature",
            "Mathematics",
            "Molecular Biology",
            "Music",
            "Neuroscience",
            "Nursing",
            "Organizational Science",
            "Philosophy",
            "Physics",
            "Political Science",
            "Psychology",
            "Public Relations",
            "Religion",
            "ROTC",
            "Social & Criminal Justice",
            "Sociology",
            "Spanish",
            "Spanish Studies",
            "Theatre Arts",
            "Writing",
            "Pre-Professional Programs",
            "Pre-Actuarial Science",
            "Pre-Architecture",
            "Pre Athletic-Training",
            "Pre-Dental",
            "Pre-Engineering",
            "Pre-Law",
            "Pre-Med",
            "Pre-Pharmacy",
            "Pre-Physical Therapy",
            "Pre-Physician Assistant",
            "Pre-Podiatry",
            "Pre-Public Health",
            "Pre-Veterinary",
            "Pre-Music Therapy",
            "Other"]

def pickMajorsOrMinors(majMin):
    subjects = []
    numOf = random.randint(0,4)
    for i in range(numOf):
        nexSubj = random.randint(0,len(majMin)-1)
        subjects.append(majMin[nexSubj])
    return subjects

def setYearsWorked():
    return random.randint(0,4)

def setHoursPerWeek():
    return random.randint(1,9)

def setFirstAndLast():
    fake = Faker()
    firstName = fake.first_name()
    lastName = fake.last_name()
    return firstName, lastName

def setAvailability():
    days = []
    for i in range(7):
        day = []
        for j in range(31):
            available = random.choice([True, False])
            if available:
                day.append(" ")
            else:
                day.append("NULL")
        days.append(day)
    return days

def consultantDriver(numUsers):
    pwd = {}
    for i in range(numUsers):
        majors = pickMajorsOrMinors(majMin)
        minors = pickMajorsOrMinors(majMin)
        first, last = setFirstAndLast()
        username = str(uuid.uuid4())
        password = "test"
        dictionary = {
            "days": setAvailability(),
            "major": majors,
            "maj": ",".join(majors),
            "minor": minors,
            "min": ",".join(minors),
            "yearsWorked": str(setYearsWorked()),
            "hoursPer": str(setHoursPerWeek()),
            "first": first,
            "last": last,
            "username": username,
            "password": password,
            "userID": username,
            "director": False
        }
        with open("users/" + str(dictionary["userID"])+".json", 'w') as outfile:
            json.dump(dictionary, outfile)
        with open("pwd.txt", "a") as outfile:
            outfile.write("\n" + username + "," + password + ",aaaah," + username)


consultantDriver(25)

use chrono::DateTime;
use chrono::Local;
use chrono::NaiveTime;
use serde::{Deserialize, Serialize};
use std::ffi::{CStr, CString, c_char};

#[derive(Serialize, Deserialize)]
pub struct WorkHours {
    pub start: NaiveTime,
    pub end: NaiveTime,
}

#[derive(Serialize, Deserialize)]
pub struct WorkTask {
    pub task_name: String,
    pub arg: String,
    pub task_time: NaiveTime,
}

#[derive(Serialize, Deserialize)]
pub struct Event {
    pub event_name: String,
    pub arg: String,
    pub event_date_time: DateTime<Local>,
}

#[no_mangle]
pub extern "C" fn new_hours(start: *const c_char, end: *const c_char) -> *mut c_char {
    let start = unsafe { CStr::from_ptr(start).to_str().unwrap() };
    let end = unsafe { CStr::from_ptr(end).to_str().unwrap() };

    let work_hours = WorkHours {
        start: NaiveTime::parse_from_str(start, "%H:%M").unwrap(),
        end: NaiveTime::parse_from_str(end, "%H:%M").unwrap(),
    };

    let json = serde_json::to_string(&work_hours).unwrap();
    CString::new(json).unwrap().into_raw()
}

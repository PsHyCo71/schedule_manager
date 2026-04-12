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

#[unsafe(no_mangle)]
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

#[unsafe(no_mangle)]
pub extern "C" fn new_task(task_name: *const c_char, arg: *const c_char, task_time: *const c_char) -> *mut c_char {
    let task_name = unsafe { CStr::from_ptr(task_name).to_str().unwrap() };
    let arg = unsafe { CStr::from_ptr(arg).to_str().unwrap() };
    let task_time = unsafe { CStr::from_ptr(task_time).to_str().unwrap() };

    let work_task = WorkTask {
        task_name: task_name.to_string(),
        arg: arg.to_string(),
        task_time: NaiveTime::parse_from_str(task_time, "%H:%M").unwrap(),
    };

    let json = serde_json::to_string(&work_task).unwrap();
    CString::new(json).unwrap().into_raw()
}

#[unsafe(no_mangle)]
pub extern "C" fn new_event(event_name: *const c_char, arg: *const c_char, event_date_time: *const c_char) -> *mut c_char {
    let event_name = unsafe { CStr::from_ptr(event_name).to_str().unwrap() };
    let arg = unsafe { CStr::from_ptr(arg).to_str().unwrap() };
    let event_date_time = unsafe { CStr::from_ptr(event_date_time).to_str().unwrap() };

    let event = Event {
        event_name: event_name.to_string(),
        arg: arg.to_string(),
        event_date_time: DateTime::parse_from_rfc3339(event_date_time).unwrap().with_timezone(&Local),
    };

    let json = serde_json::to_string(&event).unwrap();
    CString::new(json).unwrap().into_raw()
}


#[unsafe(no_mangle)]
pub extern "C" fn free_string(ptr: *mut c_char) {
    if ptr.is_null() { return; }
    unsafe { drop(CString::from_raw(ptr)); }
}
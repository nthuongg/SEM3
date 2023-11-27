import React from "react";

import Student from "./Student";
import Teacher from "./Teacher";

class ClassRoom extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            teacher: {
                name: "Trinh Quang Hoa",
                age: 18
            },
            students: [
                {
                    name:"Phung Duy Hung"
                },
                {
                    name:"Nguyen Thi Huong"
                },
                {
                    name:"Trinh Van Phuc"
                }
            ]
        }
    }
    render(){
        const teacher = this.state.teacher;
        const students = this.state.students;
        return (
            <div>
                <h2>T2210M</h2>
                <h3>Giao vien: </h3>
                <Teacher teacher={teacher}/>
                <h3>Danh sach sinh vien</h3>
                <div className="row">
                    {
                        students.map((e,i)=>{
                            return (
                                <div key={i} className="col-6">
                                    <Student  student_name={e.name}/>
                                </div>
                            )
                        })
                    }
                </div>
            </div>
        )
    }
}
export default ClassRoom;

function Student(props){
    const name = props.student_name;
    return(
        <div>
            <h2>Name: {name}</h2>
            <p>Age: 18</p>
        </div>
    )
}
export default Student;
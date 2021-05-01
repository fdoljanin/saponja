import axios from "axios";
import React from "react";
import { useEffect, useState } from "react";
import { Redirect, useHistory } from "react-router";
import {userRole} from "consts/enums";
import { useUser } from "services/providers/user/hooks";

const initialState = {
  post: {
    title: "",
    content: ""
  }
}

const AddPost = () => {
  const [postForm, setPostForm] = useState(initialState.post);
  const [photo, setPhoto] = useState();
  const user = useUser();

  if (user.role !== userRole.SHELTER)
    return <Redirect to="/" />;

  const handleChange = ({ target: { name, value } }) => {
    setPostForm((prevState) => ({
      ...prevState,
      [name]: value
    }));
  };

  const sendPost = (e) => {
    e.preventDefault();

    axios.post("api/User/CreatePost", postForm).then(({data: postId}) => {
      const formData = new FormData();
      formData.append("Photo", photo);
      axios.post(`api/User/AddPostPhoto?postId=${postId}`, formData);
    });
  }

  return (<form onSubmit={sendPost}>
    <input name="title" value={postForm.title} onChange={handleChange} />
    <textarea name="content" value={postForm.content} onChange={handleChange} />
    <input type="file" onChange={e => setPhoto(e.target.files[0])} />
    <input type="submit" />
  </form>)
}

export default AddPost;
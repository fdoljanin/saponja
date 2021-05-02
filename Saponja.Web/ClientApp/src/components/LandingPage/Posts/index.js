import React, { useEffect, useState } from "react";
import "./style.css";
import IconRight from "../../../assets/icons/icon angle right.svg";
import Chocolate from "../../../assets/landingPage_assets/cokolada.jpeg";
import axios from "axios";
import Post from "./Post";

const Posts = () => {
  const [posts, setPosts] = useState([]);

  useEffect(() => {
    axios.get("api/Visitor/GetPostsPreview?pageNumber=0")
      .then(({ data }) => setPosts(data.posts));
  }, []);

  return (
    <section className="posts">
      <div className="posts__heading-container">
        <p className="posts__heading-container-title">Novosti</p>
        <img
          src={IconRight}
          alt="strelica"
          className="posts__heading-container-arrow"
        />
      </div>
    {posts.map(post=> <Post key={post.id} post={post} />)}
    </section>
  );
};

export default Posts;

import React from "react";
import { Link } from "react-router-dom";
import { getReadableDate } from "utils/stringHelpers";

const Post = ({ post }) => {
  return (
    <div className="posts__container">
      <img src={post.photoPath} alt="Post preview image" className="posts__container-image" />
      <div>
        <p className="posts__container-date">{getReadableDate(post.timestamp)}</p>
        <p className="posts__container-title">
          {post.title}
        </p>
        <p className="posts__container-text">
          {post.contentPreview}...
    </p>
        <Link to={`/posts/${post.id}`}>
          <div className="posts__container-button">
            <p className="posts__container-button-text">
              Saznaj više{" "}
              <svg
                id="Filled"
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 24 24"
                width="16px" height="16px"
              >
                <title>168 arrow right</title>
                <path fill="#91b2cb" d="M6.293,22.293a1,1,0,1,0,1.414,1.414l8.172-8.172a5.005,5.005,0,0,0,0-7.07L7.707.293A1,1,0,0,0,6.293,1.707l8.172,8.172a3,3,0,0,1,0,4.242Z" />
              </svg>
            </p>
          </div>
        </Link>
      </div>
    </div>
  );
}

export default Post;
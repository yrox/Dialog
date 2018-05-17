import React, { Component } from "react";
import _ from "lodash";
import classNames from "classnames";

export default class Message extends Component {
  renderMessage(message) {
    const text = message.text || '';

    const messageElement = _.split(text, "\n").map((m, key) => {
      return <p key={key} dangerouslySetInnerHTML={{ __html: m }} />;
    });

    return messageElement;
  }

  render() {
    const { index, message } = this.props;
    return (
      <div key={index} className={classNames("message", { me: message.me })}>
        <div className="message-user-image">
          <img alt="pic" />
        </div>
        <div className="message-body">
          <div className="message-author">
            {message.me ? "You " : message.author} says:
          </div>
          <div className="message-text">{this.renderMessage(message)}</div>
        </div>
      </div>
    );
  }
}

import { BrowserRouter } from "react-router-dom";
import { createBrowserHistory } from "history";

export const history = createBrowserHistory({ forceRefresh: false });

export default class BrowserHistoryWrapper extends BrowserRouter {
  history;
}